<?php get_header(); ?>
			
			<div id="content">
			
				<div id="inner-content" class="wrap clearfix">
			
				    <div id="main" class="sixcol first clearfix" role="main">
				    	<h1>Games</h1>
				    	<?php 

				    		$args = array(
								'orderby' => 'date',
								'order'   => 'DESC',
								'posts_per_page' => 20,
								'post_type' => 'custom_type',
							);
							$wp_query = new WP_Query( $args );

							while ( $wp_query->have_posts() ) {
								$wp_query->the_post();
								get_template_part( 'post-formats/format-index-default', get_post_format() );
							}						
							wp_reset_postdata();
						?>


					    
			
				    </div> <!-- end #main -->

				    <div id="blog" class="sixcol last clearfix">
				    	<h1 class="text-center">Blog</h1>
				    	<?php 

				    		$args = array(
								'orderby' => 'date',
								'order'   => 'DESC',
								'posts_per_page' => 20,
								'post_type' => 'post',
							);
							$wp_query = new WP_Query( $args );

							while ( $wp_query->have_posts() ) {
								$wp_query->the_post();
								get_template_part( 'post-formats/format-index-default', get_post_format() );
							}

							bones_page_navi();

							wp_reset_postdata();						

						?>				
						

				    </div>

    
				    <!--<?php get_sidebar(); ?>-->
				    
				</div> <!-- end #inner-content -->
    
			</div> <!-- end #content -->

<?php get_footer(); ?>
